using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace VisitorCounter.Receiver
{
    internal class PipeReader
    {

        internal static void ConsolePipeReader()
        {
            Console.WriteLine("In pipe");
            string inputFromPipe;
            int AddToBuffer = 0;
            List<CommPrimitive> TempMessageBuffer = new List<CommPrimitive>();
            try
            {
                Console.WriteLine("Able to enter the try block");
                while ((inputFromPipe = Console.ReadLine()) != null)
                {
                    Console.WriteLine("Am able to read some stuff.." + inputFromPipe);
                    if (ListHolder.MuTexLock.WaitOne())
                    {
                        Console.WriteLine("Locked sucessfully");
                        if (AddToBuffer == 1)
                        {
                            Console.WriteLine("buffer to main");
                            ListHolder.MessageHolder.AddRange(TempMessageBuffer);
                            TempMessageBuffer.Clear();
                            AddToBuffer = 0;
                        }
                        Console.WriteLine("Line 50");
                        CommPrimitive comm = JsonSerializer.Deserialize<CommPrimitive>(inputFromPipe);
                        try
                        {
                            ListHolder.MessageHolder.Add(comm);
                            CountSetters.SetHourCount(comm.Date);
                            CountSetters.SetDayCount(comm.Date);
                        }
                        catch
                        {
                            Console.WriteLine("Not able to deserialize!");
                        }
                        ListHolder.MuTexLock.ReleaseMutex();
                    }
                    else
                    {
                        AddToBuffer = 1;
                        CommPrimitive comm = JsonSerializer.Deserialize<VisitorCounter.CommPrimitive>(inputFromPipe);
                        TempMessageBuffer.Add(comm);
                    }
                }
                if (ListHolder.MuTexLock.WaitOne())
                {
                    foreach (var var1 in ListHolder.MessageHolder)
                    {
                        Console.WriteLine("Data: Date = {0}", var1.Date);
                        //Console.WriteLine("Data: Time = {0}", var1.Time);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error when reading from pipe" + e);
            }
            //try
            //{
            //    CommPrimitive comm1 = new CommPrimitive();
            //    comm1.Date = new DateTime(2020, 09, 16, 20,20,30);
            //    CommPrimitive comm2 = new CommPrimitive();
            //    comm2.Date = new DateTime(2020, 09, 16, 10,20,30);
            //    CommPrimitive comm3 = new CommPrimitive();
            //    comm3.Date = new DateTime(2020, 09, 16, 10,30,40);
            //    CommPrimitive comm4 = new CommPrimitive();
            //    comm4.Date = new DateTime(2020, 09, 16, 16,20,30);
            //    CommPrimitive comm5 = new CommPrimitive();
            //    comm5.Date = new DateTime(2021, 05, 26, 6, 9, 10);


            //    //CommPrimitive comm2 = new CommPrimitive(2020, 09, 16, 2, 00, 50);
            //    //CommPrimitive comm3 = new CommPrimitive(2020, 09, 16, 2, 01, 00);
            //    //CommPrimitive comm4 = new CommPrimitive(2020, 09, 16, 2, 20, 00);
            //    //CommPrimitive comm5 = new CommPrimitive(2020, 09, 16, 2, 30, 00);
            //    //CommPrimitive comm6 = new CommPrimitive(2020, 09, 16, 2, 50, 00);
            //    //CommPrimitive comm7 = new CommPrimitive(2020, 09, 16, 3, 00, 00);
            //    //CommPrimitive comm8 = new CommPrimitive(2020, 09, 16, 3, 00, 10);
            //    //CommPrimitive comm9 = new CommPrimitive(2020, 09, 16, 4, 00, 00);
            //    //CommPrimitive comm10 = new CommPrimitive(2020, 08, 16, 6, 00, 00);
            //    //CommPrimitive comm11 = new CommPrimitive(2002, 08, 16, 4, 00, 00);
            //    try
            //    {
            //        if (ListHolder.MuTexLock.WaitOne())
            //        {
            //            ListHolder.MessageHolder.Add(comm1);
            //            CountSetters.SetHourCount(comm1.Date);
            //            CountSetters.SetDayCount(comm1.Date);
            //            ListHolder.MessageHolder.Add(comm2);
            //            CountSetters.SetHourCount(comm2.Date);
            //            CountSetters.SetDayCount(comm2.Date);
            //            ListHolder.MessageHolder.Add(comm3);
            //            CountSetters.SetHourCount(comm3.Date);
            //            CountSetters.SetDayCount(comm3.Date);
            //            ListHolder.MessageHolder.Add(comm4);
            //            CountSetters.SetHourCount(comm4.Date);
            //            CountSetters.SetDayCount(comm4.Date);
            //            ListHolder.MessageHolder.Add(comm5);
            //            CountSetters.SetHourCount(comm5.Date);
            //            CountSetters.SetDayCount(comm5.Date);
            //            //ListHolder.MessageHolder.Add(comm5);
            //            //SetHourCount(comm5);
            //            //SetDayCount(comm5);
            //            //ListHolder.MessageHolder.Add(comm6);
            //            //SetHourCount(comm6);
            //            //SetDayCount(comm6);
            //            //ListHolder.MessageHolder.Add(comm7);
            //            //SetHourCount(comm7);
            //            //SetDayCount(comm7);
            //            //ListHolder.MessageHolder.Add(comm8);
            //            //SetHourCount(comm8);
            //            //SetDayCount(comm8);
            //            //ListHolder.MessageHolder.Add(comm9);
            //            //SetHourCount(comm9);
            //            //SetDayCount(comm9);
            //            //ListHolder.MessageHolder.Add(comm10);
            //            //SetHourCount(comm10);
            //            //SetDayCount(comm10);
            //            //ListHolder.MessageHolder.Add(comm11);
            //            //SetHourCount(comm11);
            //            //SetDayCount(comm11);
            //            ListHolder.MuTexLock.ReleaseMutex();
            //        }

            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Exception in adding" + e);
            //    }
            //}
            //catch
            //{
            //    Console.WriteLine("Exception in objects..");
            //}

        }
    }
}

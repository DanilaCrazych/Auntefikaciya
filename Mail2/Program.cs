using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;
using mail;

namespace NetConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OtpravkaIproverka otpravkaIproverka = new OtpravkaIproverka();
            otpravkaIproverka.otpravka();

        }
    }
}
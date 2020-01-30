﻿using System;
using System.IO;
using System.Net;
using System.Data;
using System.Threading;


namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {

            getFile("bbt.avi", "Testing", "username", "password", "192.X.XX.X");
            

        }

        public static void getFile(String filename, String path, String username, String password, String serverAddress) {
        	
        	new Thread(() => 
			{
                try {
				Console.WriteLine("Downloading...."); 
			    FtpWebRequest request =
			    (FtpWebRequest)WebRequest.Create("ftp://" + serverAddress + "/" + path + "/" + filename);
				request.Credentials = new NetworkCredential(username, password);
				request.Method = WebRequestMethods.Ftp.DownloadFile;

				using (Stream ftpStream = request.GetResponse().GetResponseStream())

				using (Stream fileStream = File.Create(@""+filename))
				{
				    byte[] buffer = new byte[10240];
				    int read;
				    while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
				    {
				        fileStream.Write(buffer, 0, read);
				        Console.WriteLine("Downloaded {0} bytes", fileStream.Position);
				    }
				}
                }
                catch(Exception) {
                    Console.WriteLine("Connection has failed or file not available.");
                }
			    
			}).Start();
        }
    }
}
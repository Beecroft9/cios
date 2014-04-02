/**
 * --------------------------------------------------------------------------------------------------------
 * File Name:
 * Project Name:
 * --------------------------------------------------------------------------------------------------------
 * Author's Name and Email: Elijah Laws (lawseb@goldmail.etsu.edu)
 * Course-Section:
 * Creation Date:
 * Last Modified: (Name, Date, Email)
 * --------------------------------------------------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Net.Mail;

namespace CIOS.Email
{
    /**
    * Class Name: 
    * Class Purpose: 
    * 
    * Date Created: 
    * Last Modified: 
    * @author 
    */
    public class EmailSystem
    {
        public string toEmail { get; set; }     // to address
        public string subject { get; set; }     
        public string body { get; set; }
        /**
        * Method Name:
        * Method Purpose:
        * 
        * Date Created:
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * 
        * @param returnURL: 
        * @return 
        */
        public void sendNewEmail() 
        {
            // Username and password for gmail
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential();
            cred.Password = "zonecrew";
            cred.UserName = "cbatteam@gmail.com";
       
            // The email message itself
            MailMessage msg = new MailMessage();
            msg.To.Add(toEmail);
            msg.From = new MailAddress("cbatteam@gmail.com");
            msg.Headers.Add("Reply-To", "cbatteam@gmail.com");
            msg.Body = body;
            msg.IsBodyHtml = false;
            msg.Subject = subject;
        
            // A smtp client is created to send the email. 
            SmtpClient smail = new SmtpClient();
            smail.UseDefaultCredentials = false;
            smail.Credentials = cred;
            smail.DeliveryMethod = SmtpDeliveryMethod.Network;
            smail.EnableSsl = true;
            smail.Port = 587;
            smail.Host = "smtp.gmail.com";

            smail.Send(msg);
        }
    }
}
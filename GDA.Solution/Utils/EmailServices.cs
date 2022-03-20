using System.Net.Mail;

namespace GDA.Solution.Utils
{
    /// <summary>
    /// The email services.
    /// </summary>
    public static class EmailServices
    {
        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="recipient">The recipient.</param>
        public static void SendEmail(string title, string message, string recipient)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    MailMessage mail = new(EmailSettings.Email, recipient);

                    SmtpClient client = new();

                    client.EnableSsl = true;

                    client.Host = EmailSettings.Host;

                    client.UseDefaultCredentials = false;

                    client.Credentials = new System.Net.NetworkCredential(EmailSettings.Email, EmailSettings.Password);

                    client.Port = EmailSettings.Port;

                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    mail.Subject = title;

                    mail.Body = message;

                    client.Send(mail);
                });

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
/// <summary>
/// The email settings.
/// </summary>
internal static class EmailSettings
{
    /// <summary>
    /// Gets the email.
    /// </summary>
    public static string Email => "GDAEmailSender@gmail.com";
    /// <summary>
    /// Gets the display name.
    /// </summary>
    public static string DisplayName => "GDA Email";
    /// <summary>
    /// Gets the password.
    /// </summary>
    public static string Password => "$Qc4tjZpF2!2xZ-+";
    /// <summary>
    /// Gets the host.
    /// </summary>
    public static string Host => "smtp.gmail.com";
    /// <summary>
    /// Gets the port.
    /// </summary>
    public static int Port => 587;
}

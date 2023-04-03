using Microsoft.JSInterop;
using System;
using System.Net.Mail;
namespace TaskListWebApi.Helpers
{
    public class Helper
    {
        public bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public bool IsValidUrl(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }

       public bool HasHashtag(string hastagString)
        {
            return hastagString=="#important";
        }
        public bool HasAt(string atString)
        {
            return atString.StartsWith("@");
        }
        public string JustText(string text)
        {
            return text;
        }

        public List<string> SplitString(string stringToSplit)
        {
            char[] delimiterChars = { '!', '?', '¿', '¡', ' ', ',', ';', '\t' };

            List<string> wordsList = stringToSplit.Split(delimiterChars).ToList();
            return wordsList;
            
        }
        public string SplitChar(string stringToSplit)
        {
            string wordsList = stringToSplit.Substring(1, stringToSplit.Length-1);
            return wordsList;
        }

        public string FinalCheck(string text)
        {
            if (this.IsValidEmail(text))
            {
                return "IsValidEmail";
            }
            else if (this.HasAt(text))
            {
                return "HasAt";
            }
            else if (this.HasHashtag(text))
            {
                return "HasHashtag";
            }
            else if (this.IsValidUrl(text))
            {
                return "IsValidUrl";
            }
            else
            {
                return "JustText";
            }
        }
    }
}

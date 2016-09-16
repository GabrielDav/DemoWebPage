using System.Text.RegularExpressions;

namespace BusinessLogic.Validators
{
    public class EmailValidator : IEmailValidator
    {
        /// <summary>
        /// Email should contain correct domain name <see ref="https://en.wikipedia.org/wiki/Email_address#Domain"></see>
        /// </summary>
        private static readonly Regex EmailRegex = new Regex("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$",
            RegexOptions.Singleline | RegexOptions.Compiled);

        public bool IsValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length > 255)
                return false;
            return EmailRegex.IsMatch(email);
        }
    }
}

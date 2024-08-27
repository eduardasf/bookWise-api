using System.Text.RegularExpressions;

namespace Shared.Validation
{
    public partial class ValidationContract
    {
        public ValidationContract IsNotNullOrEmpty(string val, string property, string message)
        {
            if (string.IsNullOrEmpty(val))
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsNullOrEmpty(string val, string property, string message)
        {
            if (!string.IsNullOrEmpty(val))
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsNotNullOrWhiteSpace(string val, string property, string message)
        {
            if (string.IsNullOrWhiteSpace(val))
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsNullOrWhiteSpace(string val, string property, string message)
        {
            if (!string.IsNullOrWhiteSpace(val))
                AddNotification(property, message);

            return this;
        }

        public ValidationContract HasMinLen(string val, int min, string property, string message)
        {
            if ((val ?? "").Length < min)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract HasMaxLen(string val, int max, string property, string message)
        {
            if ((val ?? "").Length > max)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract HasLen(string val, int len, string property, string message)
        {
            if ((val ?? "").Length != len)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract Contains(string val, string text, string property, string message)
        {
            // TODO: StringComparison.OrdinalIgnoreCase not suported yet
            if (!(val ?? "").Contains(text))
                AddNotification(property, message);

            return this;
        }

        public ValidationContract AreEquals(string val, string text, string property, string message)
        {
            // TODO: StringComparison.OrdinalIgnoreCase not suported yet
            if (val != text)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract AreNotEquals(string val, string text, string property, string message)
        {
            // TODO: StringComparison.OrdinalIgnoreCase not suported yet
            if (val == text)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsEmail(string email, string property, string message)
        {
            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Matchs(email, pattern, property, message);
        }

        public ValidationContract IsEmailOrEmpty(string email, string property, string message)
        {
            if (string.IsNullOrEmpty(email))
                return this;

            return IsEmail(email, property, message);
        }

        public ValidationContract IsUrl(string url, string property, string message)
        {
            const string pattern = @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$";
            return Matchs(url, pattern, property, message);
        }

        public ValidationContract IsUrlOrEmpty(string url, string property, string message)
        {
            if (string.IsNullOrEmpty(url))
                return this;

            return IsUrl(url, property, message);
        }

        public ValidationContract Matchs(string text, string pattern, string property, string message)
        {
            if (!Regex.IsMatch(text ?? "", pattern))
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsCnpjCpf(string text, string property, string message)
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (text.Length == 11) return IsCPF(text, property, message);
                return IsCnpj(text, property, message);
            }
            return new ValidationContract { };
        }

        public ValidationContract IsCnpj(string text, string property, string message)
        {

            bool valido = false;

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            var cnpj = text.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                valido = false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;

            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (cnpj.EndsWith(digito))
            {
                valido = true;
            }

            if (!valido)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsCPF(string text, string property, string message)
        {
            bool valido = false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            var cpf = text.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                valido = false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (cpf.EndsWith(digito))
            {
                valido = true;
            }

            if (!valido)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsTelefone(string text, string property, string message)
        {
            bool valido = false;

            valido = Regex.IsMatch(text, @"^\(\d{2}\)\s\d\s\d{4}\-\d{4}$", RegexOptions.IgnoreCase);

            if (!valido)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsSestsenaOrItlEmail(string text, string property, string message)
        {
            bool valido = false;

            valido = Regex.IsMatch(text, @"^.*@(sestsenat|itl).*$", RegexOptions.IgnoreCase);

            if (!valido)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsAValidAlunoEmail(string text, string property, string message)
        {
            bool valido = false;

            valido = Regex.IsMatch(text, @"^.*@(gmail|outlook|hotmail)\.com$", RegexOptions.IgnoreCase);

            return this;
        }
    }
}

namespace DataValidation
{
    using System;
    public class InputValidator : IInputValitador
    {
        public void CheckForNulls(object verify, string nameOfVerifyingValue)
        {
            if (verify == null)
            {
                throw new ArgumentNullException(nameOfVerifyingValue, $"Input Parameter ({nameOfVerifyingValue}) was null or empty");
            }
        }

        public void EnsureNonNegative(decimal negativeInput, string nameOfVerifyingValue)
        {
            if (negativeInput < 0)
            {
                throw new ArgumentOutOfRangeException(nameOfVerifyingValue, "Input value needs to be positive");
            }
        }
    }
}

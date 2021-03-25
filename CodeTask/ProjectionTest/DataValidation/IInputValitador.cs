namespace DataValidation
{
    public interface IInputValitador
    {
        void CheckForNulls(object verify, string nameOfVerifyingValue);

        void EnsureNonNegative(decimal negativeInput, string nameOfVerifyingValue);
    }
}
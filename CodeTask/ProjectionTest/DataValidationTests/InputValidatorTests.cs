namespace DataValidationTests
{
    using DataValidation;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class InputValidatorTests
    {
        [Test]
        public void CheckForNullsNullInputThrowsArgumentNullException()
        {
            const string expected = "Input Parameter (verifying) was null or empty (Parameter 'verifying')";
            const object verifying = null;
            var validator = new InputValidator();


            Assert.Multiple(() =>
            {
                var exception = Assert.Throws<ArgumentNullException>(() => validator.CheckForNulls(verifying, nameof(verifying)));
                Assert.AreEqual(expected, exception.Message);
            });
        }

        [Test]
        public void CheckForNullsNonNullStringInputDoesNotThrowArgumentNullException()
        {
            const string verifying = "I'm not null";
            var validator = new InputValidator();

            Assert.DoesNotThrow(() => validator.CheckForNulls(verifying, nameof(verifying)));
        }

        [Test]
        public void CheckForNullsNonNullIntInputDoesNotThrowArgumentNullException()
        {
            const int verifying = 0;
            var validator = new InputValidator();

            Assert.DoesNotThrow(() => validator.CheckForNulls(verifying, nameof(verifying)));
        }

        [Test]
        public void CheckForNullsNonNullListInputDoesNotThrowArgumentNullException()
        {
            List<string> verifying = new List<string>() { "I'm not null" };
            var validator = new InputValidator();

            Assert.DoesNotThrow(() => validator.CheckForNulls(verifying, nameof(verifying)));
        }

        [Test]
        public void EnsureNonNegativeThrowsExceptionWhenNegativeIntIsPassed()
        {
            var validator = new InputValidator();
            const int negativeInput = -1;
            const string expected = "Input value needs to be positive (Parameter 'negativeInput')";


            Assert.Multiple(() =>
            {
                var exception = Assert.Throws<ArgumentOutOfRangeException>(() => validator.EnsureNonNegative(negativeInput, nameof(negativeInput)));
                Assert.AreEqual(expected, exception.Message);
            });
        }

        [Test]
        public void EnsureNonNegativeDoesNotThrowExceptionWhenZeroValueIntIsPassed()
        {
            var validator = new InputValidator();
            const int input = 0;
 
            Assert.DoesNotThrow(() => validator.EnsureNonNegative(input, nameof(input)));
        }

        [Test]
        public void EnsureNonNegativeDoesNotThrowExceptionWhenPositiveValueIntIsPassed()
        {
            var validator = new InputValidator();
            const int input = 1;

            Assert.DoesNotThrow(() => validator.EnsureNonNegative(input, nameof(input)));
        }
    }
}
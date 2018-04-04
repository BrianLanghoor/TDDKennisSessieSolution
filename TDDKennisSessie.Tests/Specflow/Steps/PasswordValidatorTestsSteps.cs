using System.Linq;
using FluentAssertions;
using TDDKennisSessie.Models;
using TDDKennisSessie.TddExamples;
using TechTalk.SpecFlow;

namespace TDDKennisSessie.Tests.Specflow.Steps
{
    [Binding]
    public class PasswordValidatorTestsSteps
    {
        private string password;
        private ValidatedPassword result;
        private readonly PasswordValidator passwordValidator = new PasswordValidator();

        [Given(@"a valid password")]
        public void GivenAValidPassword()
        {
            password = "abcDEF123";
        }
        
        [Given(@"a invalid password")]
        public void GivenAInvalidPassword()
        {
            password = "a";
        }
        
        [Given(@"the password (.*)")]
        public void GivenThePassword(string givenPassword)
        {
            password = givenPassword;
        }
        
        [When(@"I validate that password")]
        public void WhenIValidateThatPassword()
        {
            result = passwordValidator.Validate(password);
        }
        
        [Then(@"the password validation result should be valid")]
        public void ThenThePasswordValidationResultShouldBeValid()
        {
            result.IsValid.Should().BeTrue();
        }
        
        [Then(@"the password validation result should be invalid")]
        public void ThenThePasswordValidationResultShouldBeInvalid()
        {
            result.IsValid.Should().BeFalse();
        }
        
        [Then(@"the error message should be: (.*)")]
        public void ThenTheErrorMessageShouldBe(string expectedErrorMessage)
        {
            result.ErrorMessages.First().Should().Be(expectedErrorMessage);
        }
    }
}

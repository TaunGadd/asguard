using AsGuard.Api.Validator.Exceptions;

namespace AsGuard.Api.Validator;

public static class Guard
{
    public static GuardConditions Against => new GuardConditions();

    public class GuardConditions
    {
        public GuardConditions NullValue(object? input, string paramName)
        {
            if (input == null)
            {
                throw new BadRequestException($"{paramName} cannot be null.");
            }

            return this;
        }

        public GuardConditions NegativeOrZeroValue(int input, string paramName)
        {
            if (input <= 0)
            {
                throw new BadRequestException($"{paramName} must be greater than zero.");
            }

            return this;
        }
    }
}

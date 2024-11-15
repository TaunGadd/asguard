using AsGuard.Api.Validator.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace AsGuard.Api.Validator;

/// <summary>
/// Provides a fluent API for guarding against invalid arguments, values and entities.
/// </summary>
public class Guard
{
    /// <summary>
    /// Entry point for fluent guard statements. Use <see cref="Argument"/> for method arguments,
    /// <see cref="Value"/> for general values, and <see cref="Entity"/> for database entities.
    /// </summary>
    public static Guard Against { get; } = new Guard();

    /// <summary>
    /// Guard against invalid method arguments. 
    /// Use this for parameters explicitly passed to a method.
    /// </summary>
    public GuardArgument Argument { get; } = new GuardArgument();

    /// <summary>
    /// Guard against invalid values. 
    /// Use this for variables or data that need validation within the logic of your code.
    /// </summary>
    public GuardValue Value { get; } = new GuardValue();

    /// <summary>
    /// Guard against invalid database entities. 
    /// Use this for database entities that have resulted from an ORM (such as Entity Framework).
    /// </summary>
    public GuardEntity Entity { get; } = new GuardEntity();

    // Private constructor to prevent direct instantiation.
    private Guard() { }

    /// <summary>
    /// Provides guard methods for method arguments.
    /// </summary>
    public class GuardArgument
    {
        /// <summary>
        /// Ensures that the specified argument is not null. Throws an <see cref="BadRequestException"/> if null.
        /// </summary>
        /// <param name="parameter">The argument to check.</param>
        /// <param name="parameterName">The name of the parameter being checked.</param>
        /// <returns>The current <see cref="GuardArgument"/> instance for chaining further validations.</returns>
        /// <exception cref="BadRequestException">Thrown if <paramref name="parameter"/> is null.</exception>
        public GuardArgument Null([NotNull] object? parameter, string parameterName)
        {
            if (parameter == null)
            {
                throw new BadRequestException($"Argument {parameterName} cannot be null.");
            }

            return this;
        }

        // TODO Add check for negative or zero value int
        // TODO Add check for empty collection
        // TODO Add check for empty string
    }

    /// <summary>
    /// Provides guard methods for general values.
    /// </summary>
    public class GuardValue
    {
        /// <summary>
        /// Ensures that the specified value is not null. Throws an <see cref="InternalServerErrorException"/> if null.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="parameterName">The name of the parameter associated with the value (used for exception clarity).</param>
        /// <returns>The current <see cref="GuardValue"/> instance for chaining further validations.</returns>
        /// <exception cref="InternalServerErrorException">Thrown if <paramref name="value"/> is null.</exception>
        public GuardValue Null([NotNull] object? value, string parameterName)
        {
            if (value == null)
            {
                throw new InternalServerErrorException($"Value {parameterName} cannot be null.");
            }

            return this;
        }

        /// <summary>
        /// Ensures that the specified integer is not negative or zero. 
        /// Throws an <see cref="InternalServerErrorException"/> if the value is less than or equal to zero.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="parameterName">The name of the parameter associated with the value (used for exception clarity).</param>
        /// <returns>The current <see cref="GuardValue"/> instance for chaining further validations.</returns>
        /// <exception cref="InternalServerErrorException">Thrown if <paramref name="number"/> is less than or equal to zero.</exception>
        public GuardValue NegativeOrZeroValue(int number, string parameterName)
        {
            if (number <= 0)
            {
                throw new InternalServerErrorException($"Value {parameterName} must be greater than zero.");
            }

            return this;
        }

        // TODO Add check for empty collection
        // TODO Add check for empty string
    }

    public class GuardEntity
    {
        /// <summary>
        /// Ensures that the specified entity is not null. Throws an <see cref="NotFoundException"/> if null.
        /// </summary>
        /// <param name="entity">The entity to check.</param>
        /// <param name="parameterName">The name of the parameter being checked.</param>
        /// <returns>The current <see cref="GuardEntity"/> instance for chaining further validations.</returns>
        /// <exception cref="NotFoundException">Thrown if <paramref name="parameter"/> is null.</exception>
        public GuardEntity Null([NotNull] object? entity, string parameterName)
        {
            if (entity == null)
            {
                throw new NotFoundException($"Entity {parameterName} cannot be null.");
            }

            return this;
        }

        // TODO Add check for empty collection
        // TODO Add check for empty string
    }
}

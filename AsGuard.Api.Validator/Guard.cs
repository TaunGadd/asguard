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

        /// <summary>
        /// Ensures that the specified integer argument is greater than zero. 
        /// Throws an <see cref="BadRequestException"/> if the value is zero or negative.
        /// </summary>
        /// <param name="parameter">The integer to check.</param>
        /// <param name="parameterName">The name of the parameter being checked.</param>
        /// <returns>The current <see cref="GuardArgument"/> instance for chaining further validations.</returns>
        /// <exception cref="BadRequestException">Thrown if <paramref name="parameter"/> is zero or negative.</exception>
        public GuardArgument NegativeOrZero(int parameter, string parameterName)
        {
            if (parameter <= 0)
            {
                throw new BadRequestException($"Argument {parameterName} must be greater than zero.");
            }

            return this;
        }

        /// <summary>
        /// Ensures that the specified collection is not empty. 
        /// Throws an <see cref="BadRequestException"/> if the collection is null or contains no elements.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="parameter">The collection to check.</param>
        /// <param name="parameterName">The name of the parameter being checked.</param>
        /// <returns>The current <see cref="GuardArgument"/> instance for chaining further validations.</returns>
        /// <exception cref="BadRequestException">Thrown if <paramref name="parameter"/> is null or empty.</exception>
        public GuardArgument EmptyCollection<T>(IEnumerable<T>? parameter, string parameterName)
        {
            if (parameter == null || !parameter.Any())
            {
                throw new BadRequestException($"Argument {parameterName} cannot be null or an empty collection.");
            }

            return this;
        }

        /// <summary>
        /// Ensures that the specified string is not null or empty. 
        /// Throws an <see cref="BadRequestException"/> if the string is null or empty.
        /// </summary>
        /// <param name="parameter">The string to check.</param>
        /// <param name="parameterName">The name of the parameter being checked.</param>
        /// <returns>The current <see cref="GuardArgument"/> instance for chaining further validations.</returns>
        /// <exception cref="BadRequestException">Thrown if <paramref name="parameter"/> is null or empty.</exception>
        public GuardArgument EmptyString(string? parameter, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(parameter))
            {
                throw new BadRequestException($"Argument {parameterName} cannot be null or empty.");
            }

            return this;
        }
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

        /// <summary>
        /// Ensures that the specified collection is not empty. 
        /// Throws an <see cref="InternalServerErrorException"/> if the collection is null or contains no elements.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="collectionName">The name of the parameter associated with the value (used for exception clarity).</param>
        /// <returns>The current <see cref="GuardValue"/> instance for chaining further validations.</returns>
        /// <exception cref="InternalServerErrorException">Thrown if <paramref name="collection"/> is null or empty.</exception>
        public GuardValue EmptyCollection<T>(IEnumerable<T>? collection, string collectionName)
        {
            if (collection == null || !collection.Any())
            {
                throw new InternalServerErrorException($"Value {collectionName} cannot be null or an empty collection.");
            }

            return this;
        }

        /// <summary>
        /// Ensures that the specified string is not null or empty. 
        /// Throws an <see cref="InternalServerErrorException"/> if the string is null or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="parameterName">The name of the parameter associated with the value (used for exception clarity).</param>
        /// <returns>The current <see cref="GuardValue"/> instance for chaining further validations.</returns>
        /// <exception cref="InternalServerErrorException">Thrown if <paramref name="value"/> is null or empty.</exception>
        public GuardValue EmptyString(string? value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InternalServerErrorException($"Value {parameterName} cannot be null or empty.");
            }

            return this;
        }
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

        /// <summary>
        /// Ensures that the specified entity collection is not empty. 
        /// Throws an <see cref="NotFoundException"/> if the collection is null or contains no elements.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="entity">The collection entity to check.</param>
        /// <param name="entityName">The name of the entity being validated (used for exception clarity).</param>
        /// <returns>The current <see cref="GuardEntity"/> instance for chaining further validations.</returns>
        /// <exception cref="NotFoundException">Thrown if <paramref name="entity"/> is null or empty.</exception>
        public GuardEntity EmptyCollection<T>(IEnumerable<T>? entity, string entityName)
        {
            if (entity == null || !entity.Any())
            {
                throw new NotFoundException($"Entity {entityName} cannot be null or an empty collection.");
            }

            return this;
        }

        /// <summary>
        /// Ensures that the specified entity string is not null or empty. 
        /// Throws an <see cref="NotFoundException"/> if the string is null or empty.
        /// </summary>
        /// <param name="entity">The string entity to check.</param>
        /// <param name="entityName">The name of the entity being validated (used for exception clarity).</param>
        /// <returns>The current <see cref="GuardEntity"/> instance for chaining further validations.</returns>
        /// <exception cref="NotFoundException">Thrown if <paramref name="entity"/> is null or empty.</exception>
        public GuardEntity EmptyString(string? entity, string entityName)
        {
            if (string.IsNullOrWhiteSpace(entity))
            {
                throw new NotFoundException($"Entity {entityName} cannot be null or empty.");
            }

            return this;
        }
    }
}

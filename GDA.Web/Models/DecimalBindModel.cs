using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GDA.Web.Models
{
    /// <summary>
    /// The decimal bind model.
    /// </summary>
    public class DecimalBindModel : IModelBinderProvider
    {
        /// <summary>
        /// Gets the binder.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>An IModelBinder.</returns>
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(decimal))
            {
                return new DecimalModelBinder();
            }

            return null;
        }
    }

    /// <summary>
    /// The decimal model binder.
    /// </summary>
    public class DecimalModelBinder : IModelBinder
    {
        /// <summary>
        /// Binds the model async.
        /// </summary>
        /// <param name="bindingContext">The binding context.</param>
        /// <returns>A Task.</returns>
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult == default)
            {
                return Task.CompletedTask;
            }

            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            // Remove unnecessary commas and spaces
            value = value.Replace('.', ',').Trim();

            decimal myValue;
            if (!decimal.TryParse(value, out myValue))
            {
                // Error
                bindingContext.ModelState.TryAddModelError(
                                        bindingContext.ModelName,
                                        "Could not parse MyValue.");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(myValue);
            return Task.CompletedTask;
        }

    }
}

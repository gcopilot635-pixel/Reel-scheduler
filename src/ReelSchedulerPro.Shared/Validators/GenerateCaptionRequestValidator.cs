using FluentValidation;
using ReelSchedulerPro.Shared.DTOs.Captions;

namespace ReelSchedulerPro.Shared.Validators;

/// <summary>
/// Validator for GenerateCaptionRequest
/// </summary>
public class GenerateCaptionRequestValidator : AbstractValidator<GenerateCaptionRequest>
{
    public GenerateCaptionRequestValidator()
    {
        RuleFor(x => x.OriginalCaption)
            .NotEmpty().WithMessage("Original caption is required")
            .MinimumLength(5).WithMessage("Caption must be at least 5 characters")
            .MaximumLength(2200).WithMessage("Caption must not exceed 2200 characters");

        RuleFor(x => x.Topic)
            .MaximumLength(100).WithMessage("Topic must not exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.Topic));

        RuleFor(x => x.Style)
            .InclusiveBetween(1, 5).WithMessage("Style must be between 1 and 5");
    }
}

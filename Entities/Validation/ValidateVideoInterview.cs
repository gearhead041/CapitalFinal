

namespace Entities.Validation;

using Entities.Dtos;
using System.ComponentModel.DataAnnotations;

public class ValidateVideoInterview: ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        try
        {
            var stageDto = (CreateStageDto)validationContext.ObjectInstance;
            if (stageDto.StageType.ToLower().Trim() == "videointerview")
            {
                // If StageType is "VideoInterview," ensure VideoInterviewStageDto is not null
                if (value == null)
                {
                    return new ValidationResult("VideoInterviewStageDto is required when StageType is VideoInterview.");
                }
            }
        }
        catch (InvalidCastException)
        {
            var stageDto = (StageDto)validationContext.ObjectInstance;
            if (stageDto.StageType.ToLower().Trim() == "videointerview")
            {
                // If StageType is "VideoInterview," ensure VideoInterviewStageDto is not null
                if (value == null)
                {
                    return new ValidationResult("VideoInterviewStageDto is required when StageType is VideoInterview.");
                }
            }
        }



        // Validation passed or not applicable
        return ValidationResult.Success;
    }
}

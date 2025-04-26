using POC.Grpc.App.Application.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POC.Grpc.App.Application.Models.Customer;

public class CustomerViewModel
{
    [DisplayName("Id")]
    [Required(ErrorMessage = "Id is required.")]
    [Range(1, long.MaxValue - 1, ErrorMessage = $"Id must be greater than 0 and less than the maximum allowed.")]
    public long Id { get; init; }

    [DisplayName("Name")]
    [Required(ErrorMessage = "Name is required.")]
    [MinLength(15, ErrorMessage = "Name must be at least 15 characters long.")]
    [MaxLength(100, ErrorMessage = "Name must not exceed 100 characters.")]
    public string Name { get; init; }

    [DisplayName("Birth")]
    [Required(ErrorMessage = "Birth date is required.")]
    [DataType(DataType.Date)]
    [CustomValidation(typeof(CustomerViewModel), nameof(ValidateBirthDate))]
    public DateTime Birth { get; init; }

    [DisplayName("Active")]
    public bool Active { get; init; }

    [DisplayName("Gender")]
    [Required(ErrorMessage = "Gender is required.")]
    [Range(0, 1, ErrorMessage = "Gender is required.")]
    public Gender Gender { get; init; }

    [DisplayName("Cash Balance")]
    [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
    [Required(ErrorMessage = "Cash balance is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Cash balance must be greater than 0 and less than the maximum allowed.")]
    public double CashBalance { get; init; }

    public static ValidationResult ValidateBirthDate(object value, ValidationContext context)
    {
        if (value is DateTime birth)
        {
            return birth > DateTime.Today
                ? new ValidationResult("Birth date cannot be greater than today's date.")
                : ValidationResult.Success;
        }

        return new ValidationResult("Invalid birth date format.");
    }
}
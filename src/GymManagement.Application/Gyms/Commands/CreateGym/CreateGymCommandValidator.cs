using FluentValidation;

namespace GymManagement.Application.Gyms.Commands.CreateGym;
public class CreateGymCommandValidator : AbstractValidator<CreateGymCommand>
{
	public CreateGymCommandValidator()
	{
		RuleFor(v => v.Name)
			.MinimumLength(3)
			.MaximumLength(50);
	}
}
using FluentValidation;
using srbetancBBDDSQl.Entity;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Entrada;

namespace srbetancBBDDSQl.Infrastructure.Validaciones
{
    public class ValidateBeneficiario : AbstractValidator<EHistorialEvento>
    {
        /// <summary>
        /// 
        /// </summary>
        public ValidateBeneficiario()
        {
            RuleFor(eBeneficiario => eBeneficiario.PackageId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(EConstantes.IdentificacionDescription).WithErrorCode(EConstantes.NuloVacioCode)
                .NotNull().WithMessage(EConstantes.IdentificacionDescription).WithErrorCode(EConstantes.NuloVacioCode);

            RuleFor(eBeneficiario => eBeneficiario.AppId).Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage(EConstantes.TipoIdentificacionDescription).WithErrorCode(EConstantes.NuloVacioCode)
               .NotNull().WithMessage(EConstantes.TipoIdentificacionDescription).WithErrorCode(EConstantes.NuloVacioCode);
        }
    }
}

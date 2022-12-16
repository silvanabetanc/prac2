using BP.API.Entidades;
using BP.Comun.Extensiones;
using FluentValidation;
using srbetancBBDDSQl.Entity;
using srbetancBBDDSQl.Entity.Instancias.InstanciaUno.Entrada;

namespace srbetancBBDDSQl.Infrastructure.Validaciones
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidateEBasicoTransaccion : AbstractValidator<EEntrada<EHistorialEvento>>
    {
        /// <summary>
        ///
        /// </summary>
        public ValidateEBasicoTransaccion()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(eBasicoTransaccion => eBasicoTransaccion.HeaderIn).NotNull().WithMessage(EConstantes.HeaderInNullDescription).WithErrorCode(EConstantes.HeaderInNullCode);
            When(eBasicoTransaccion => eBasicoTransaccion.HeaderIn.IsNotNull(), () =>
            {
                RuleFor(eBasicoTransaccion => eBasicoTransaccion.HeaderIn).SetValidator(new ValidateHeaderIn());
            });
            RuleFor(eBasicoTransaccion => eBasicoTransaccion.BodyIn).NotNull().WithMessage(EConstantes.BodyNullDescription).WithErrorCode(EConstantes.BodyNullCode);
            When(eBasicoTransaccion => eBasicoTransaccion.BodyIn.IsNotNull(), () =>
            {
                RuleFor(eBasicoTransaccion => eBasicoTransaccion.BodyIn).SetValidator(new ValidateBeneficiario());
            });
        }
    }
}

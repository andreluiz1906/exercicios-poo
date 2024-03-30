namespace DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Interfaces.Validadores;

public interface IValidador<T>
{
    bool Validar(T objeto);
}
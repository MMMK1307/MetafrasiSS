namespace MetafrasiSS.Infra.Common.Configuration;
public class SmtpSettings
{
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
    public string Username { get; set; }
    public string Name { get; set; }
    public string Host { get; set; }
    public string Pass { get; set; }
    public int Door { get; set; }
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
}

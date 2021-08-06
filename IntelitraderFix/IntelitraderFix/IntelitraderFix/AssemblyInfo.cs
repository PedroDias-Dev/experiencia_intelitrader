using System.Runtime.InteropServices;

// Nos projetos no estilo SDK como este, vários atributos de assembly que sempre eram
// definidos nesse arquivo agora são adicionados automaticamente durante o build e
// populados com os valores definidos nas propriedades do projeto. Para obter detalhes
// de quais atributos são incluídos e como personalizar esse processo, confira: https://aka.ms/assembly-info-properties


// A definição de ComVisible como false torna os tipos neste assembly invisíveis para
// os componentes do COM. Se for necessário acessar um tipo do COM neste assembly,
// defina o atributo ComVisible como true nesse tipo.

[assembly: ComVisible(false)]

// O GUID a seguir será destinado à ID de typelib se este projeto for exposto ao COM.

[assembly: Guid("452a5c2a-7bcd-42d7-8130-3a71ee3d0e42")]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

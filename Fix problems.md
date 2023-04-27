# DBeaver
	Драйвер не настроен для аутентификации по Windows auth : поместить mssql-jdbc_auth-9.2.1.x64.dll файл в DBeaver\jre\bin

# Цепочка сертификатов выпущена центром сертификации, не имеющим доверия
	Прописать в строку подключения TrustServerCetificate=true

# .NET
## Скомпилировать один файл
	dotnet publish -c Release -o publish -p:PublishReadyToRun=true -p:PublishSingleFile=true  --self-contained true -p:IncludeNativeLibrariesForSelfExtract=true -r win-x64  
	
Добавить в .csproj
	**<PublishSingleFile>true</PublishSingleFile>**
	**<SelfContained>true</SelfContained>**
	**<RuntimeIdentifier>win-x64</RuntimeIdentifier>
	\<IncludeNativeLibrariesForSelfExtract>true</IncludeNativeLibrariesForSelfExtract>**
## WPF
	Context menu item binding to viewModel: https://stackoverflow.com/questions/3583507/wpf-binding-a-contextmenu-to-an-mvvm-command

## ASP.NET 
### Не работает IntelliSense для jQuery
	Добавить файл _references.js, в него поместить строку - ///<reference path="../lib/jquery/dist/jquery.js" /> - держать файл открытым.

### ASP.NET 403 forbidden when deploy
 	Just add the following to your web config: <system.webServer> 
                                                <modules runAllManagedModulesForAllRequests="true" /> 
                                                                                   
# Git behind proxy
Добавить в .gitconfig

	[http]
		proxy = https://rosneft\\TorgashinAA:password@knipi-proxy.rosneft.ru:8080
		sslVerify = false
	[credential]
		helper = wincred
	
## ssl certificate problem unable to get local issuer certificat
	Выполнить в cmd: git config --global http.sslbackend schannel
	

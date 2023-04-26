ssl certificate problem unable to get local issuer certificat : git config --global http.sslbackend schannel
DBeaver: драйвер не настроен для аутентификации по Windows auth : поместить mssql-jdbc_auth-9.2.1.x64.dll файл в DBeaver\jre\bin
Цепочка сертификатов выпущена центром сертификации, не имеющим доверия : прописать в строку подключения TrustServerCetificate=true

Скомпилировать один файл: dotnet publish -c Release -o publish -p:PublishReadyToRun=true -p:PublishSingleFile=true  --self-contained true -p:IncludeNativeLibrariesForSelfExtract=true -r win-x64  
Context menu item binding to viewModel: https://stackoverflow.com/questions/3583507/wpf-binding-a-contextmenu-to-an-mvvm-command

Не работает IntelliSense для jQuery: добавить файл _references.js, в него поместить строку - ///<reference path="../lib/jquery/dist/jquery.js" /> - держать файл открытым.

ASP.NET 403 forbidden when deploy : Just add the following to your web config: <system.webServer> 
                                                                                   <modules runAllManagedModulesForAllRequests="true" /> 
                                                                                   
# Git behind proxy
Добавить в .gitconfig

[http]
	proxy = https://rosneft\\TorgashinAA:password@knipi-proxy.rosneft.ru:8080
	sslVerify = false
[credential]
	helper = wincred

# App Eventos

Aplicativo .NET MAUI para a atividade de Cadastro de Eventos da ETEC. Preencha o formulário e selecione **Ver resumo** para conferir os dados, a duração e o custo total. **Editar cadastro** retorna ao formulário com os campos preenchidos.

## Como executar

Abra `AppEventos.slnx` no Visual Studio com o SDK do .NET 11 e a carga de trabalho **Desenvolvimento de interface do usuário de aplicativos multiplataforma .NET**. Selecione **Windows Machine** ou um dispositivo/emulador **Android** e pressione **F5**.

No Windows, também é possível executar pelo terminal na pasta da solução.

```powershell
dotnet build AppEventos/AppEventos.csproj -t:Run -f net11.0-windows10.0.19041.0 -p:TargetFrameworks=net11.0-windows10.0.19041.0
```

## Como funciona

- As duas páginas usam `BindingContext` com a classe `Evento`. O formulário vincula os seis campos ao modelo e valida os dados antes de abrir o resumo.
- A subtração entre as duas datas (`DateTime`) produz um `TimeSpan`. O resumo exibe `TimeSpan.Days`. Datas iguais representam 0 dias decorridos.
- O custo total é o número de participantes vezes o custo por participante, calculado com `decimal`. O cadastro aceita vírgula ou ponto decimal e custo zero. O resumo usa datas e moeda no padrão brasileiro.

## Demonstração

[PDF com capturas do formulário e do resumo](docs/Cadastro-de-Eventos.pdf)

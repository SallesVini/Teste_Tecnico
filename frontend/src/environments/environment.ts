// a pasta environments é usada para gerenciar variáveis de configuração que mudam dependendo do
// ambiente em que a aplicação está rodando

// Para que serve na prática:
// Guardar URLs de APIs diferentes por ambiente
// Ativar ou desativar logs e debug
// Configurar chaves de serviços externos (Firebase, Google Maps, etc.)
// Evitar que dados sensíveis fiquem espalhados pelo código

// Nesse caso vamos usar para guardar a URL da API .Net que vamos consumir
export const environment = {
  production: false,
  ApiUrl: "https://localhost:7287/api"
};

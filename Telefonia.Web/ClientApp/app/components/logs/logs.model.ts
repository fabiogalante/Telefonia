export interface LogModel {
    Id: number;
    Data: Date;
    LogOrigemId: number;
    Severidade: string;
    Mensagem: string;
    ArquivoFonte: string;
    MetodoFonte: string;
    LinhaFonte: number;
    Maquina: string;
    Propriedades: string;
    Excecao: string;
    UsuarioId: number;
    LogContextoId: number;
}
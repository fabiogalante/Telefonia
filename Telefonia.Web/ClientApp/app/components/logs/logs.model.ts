export interface LogModel {
    logSistemaId: number;
    data: Date;
    logOrigemId: number;
    severidade: string;
    mensagem: string;
    arquivoFonte: string;
    metodoFonte: string;
    linhaFonte: number;
    maquina: string;
    propriedades: string;
    excecao: string;
    usuarioId: number;
    logContextoId: number;
}
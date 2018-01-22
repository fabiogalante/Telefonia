import { Component, OnInit } from '@angular/core';
import { ImportacaoService } from './importacao.service';

@Component({
    selector: 'importacao',
    templateUrl: './importacao.component.html'
})

export class ImportacaoComponent implements OnInit {

    dataInicial: any;

    constructor(private importacaoService: ImportacaoService) { }

    ngOnInit() { }

    private importData(dataInicial: string) {

        if (dataInicial == "") return;

        this.importacaoService.ObterDados(dataInicial).subscribe(
            error => alert('Não foi possível importar os dados.'),
            () => alert('Dados importados com sucesso.')
        );
    }

    btnImportarClick(event: Event) {
        this.importData(this.dataInicial);
    }
}
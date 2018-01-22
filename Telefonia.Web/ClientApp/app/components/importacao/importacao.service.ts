import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ImportacaoService {

    constructor(private http: Http) { }

    //Get Logs
    ObterDados(dataInicial: string) {

        var datePipe = new DatePipe("pt-BR");
        var strData = datePipe.transform(dataInicial, 'dd-MM-yyyy');

        return this.http.get("http://127.0.0.1:5003/api/importacao/importar/?strData=" + strData).map(data => data.json());
    }
}
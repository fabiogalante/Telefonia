import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

import { LogModel } from './logs.model';

@Injectable()
export class LogsService {

    constructor(private http: Http) { }

    //Get Logs
    getLogsByDateRange(dataInicial: string, dataFinal: string) {

        var datePipe = new DatePipe("pt-BR");
        var strdataInicial = datePipe.transform(dataInicial, 'dd-MM-yyyy');
        var strdataFinal = datePipe.transform(dataFinal, 'dd-MM-yyyy');

        return this.http.get("http://127.0.0.1:5003/api/logs/obter?strDataInicial=" + strdataInicial + "&strDataFinal=" + strdataFinal).map(data => <LogModel[]>data.json());
    }
}
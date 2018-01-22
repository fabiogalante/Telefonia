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
        var strdataInicial = datePipe.transform(dataInicial, 'yyyyMMddT000000');
        var strdataFinal = datePipe.transform(dataFinal, 'yyyyMMddT105959');

        return this.http.get("/api/logsistemas?strDataInicial=" + strdataInicial + "&strdataFinal=" + strdataFinal).map(data => <LogModel[]>data.json());
    }
}
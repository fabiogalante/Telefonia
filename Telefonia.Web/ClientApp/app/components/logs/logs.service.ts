import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

//import 'rxjs/add/operator/map';
//import { Observable } from 'rxjs/Observable';

import { LogModel } from './logs.model';

@Injectable()
export class LogsService {

    constructor(private http: Http) { }

    //Get Logs
    getLogsByDateRange(startDateString: string, endDateString: string) {
        var datePipe = new DatePipe("en-US");
        var startDate = datePipe.transform(startDateString, 'yyyyMMddT000000');
        var endDate = datePipe.transform(endDateString, 'yyyyMMddT105959');

        return this.http.get("/api/logsistemas/daterange/" + startDate + "/" + endDate).map(data => <LogModel[]>data.json());
    }
}
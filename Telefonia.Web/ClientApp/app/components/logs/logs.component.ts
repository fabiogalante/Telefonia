import { Component, OnInit } from '@angular/core';
import { LogsService } from './logs.service';
import { LogModel } from './logs.model';

@Component({
    selector: 'log',
    templateUrl: './logs.component.html'
})
export class LogsComponent implements OnInit {

    logs: LogModel[] = [];

    constructor(private logService: LogsService) { }

    private getLogsByDateRange(dataInicial: string, dataFinal: string) {

        if (dataInicial == "" || dataFinal == "") return;

        this.logService.getLogsByDateRange(dataInicial, dataFinal).subscribe(
            data => this.logs = data,
            error => alert(error),
            () => console.log(this.logs)
        );
    }

    ngOnInit() { }

    changeDate(event: Event) {
        this.getLogsByDateRange((<HTMLInputElement>document.getElementById('dataInicial')).value, (<HTMLInputElement>document.getElementById('dataFinal')).value);
    }
}
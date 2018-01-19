import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppModuleShared } from './app.module.shared';
import { AppComponent } from './components/app/app.component';

import { LogsService } from './components/logs/logs.service';
import { ImportacaoService } from './components/importacao/importacao.service';

@NgModule({
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppModuleShared
    ],
    providers: [
        LogsService,
        ImportacaoService,
        { provide: 'BASE_URL', useFactory: getBaseUrl }
    ]
})

export class AppModule { }

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
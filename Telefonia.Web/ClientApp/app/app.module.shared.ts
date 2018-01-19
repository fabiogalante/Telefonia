import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { LogsComponent } from './components/logs/logs.component';
import { ImportacaoComponent } from './components/importacao/importacao.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        LogsComponent,
        ImportacaoComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'logs', component: LogsComponent },
            { path: 'importacao', component: ImportacaoComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared { }
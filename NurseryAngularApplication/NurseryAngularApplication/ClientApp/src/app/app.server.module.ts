import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { ModuleMapLoaderModule } from '@nguniversal/module-map-ngfactory-loader';
import { AppComponent } from './app.component';
import { AppModule } from './app.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  imports: [AppModule, ServerModule, ModuleMapLoaderModule, BrowserModule, FormsModule, ReactiveFormsModule],
    bootstrap: [AppComponent]
})
export class AppServerModule { }

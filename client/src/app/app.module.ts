import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {BsDropdownModule} from "ngx-bootstrap/dropdown";
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import {AppRoutingModule} from "./app-routing.module";
import {ToastrModule} from "ngx-toastr";
import {SharedModule} from "./_modules/shared.module";
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import {ErrorInterceptor} from "./_interceptors/error.interceptor";
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberCardComponent } from './members/member-card/member-card.component';
import {JwtInterceptor} from "./_interceptors/jwt.interceptor";
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import {NgxSpinnerModule} from "ngx-spinner";
import {LoadingInterceptor} from "./_interceptors/loading.interceptor";
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { PhotoEditorComponent } from './members/photo-editor/photo-editor.component';
import {TrackListComponent} from "./tracks/track-list/track-list.component";
import {TrackCardComponent} from "./tracks/track-card/track-card.component";

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    MemberListComponent,
    MemberDetailComponent,
    MemberCardComponent,
    MemberEditComponent,
    TextInputComponent,
    PhotoEditorComponent,
    TrackListComponent,
    TrackCardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    SharedModule,
    NgxSpinnerModule,
    ReactiveFormsModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

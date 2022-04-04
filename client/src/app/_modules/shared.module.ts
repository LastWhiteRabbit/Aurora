import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {BsDropdownModule} from "ngx-bootstrap/dropdown";
import {ToastrModule} from "ngx-toastr";
import {TabsModule} from "ngx-bootstrap/tabs";
import {NgxSpinnerModule} from "ngx-spinner";
import {PaginationModule} from "ngx-bootstrap/pagination";
import {FileUploadModule} from "ng2-file-upload";



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    TabsModule.forRoot(),
    NgxSpinnerModule,
    PaginationModule.forRoot(),
    FileUploadModule
  ],
  exports:[
    BsDropdownModule,
    ToastrModule,
    TabsModule,
    NgxSpinnerModule,
    PaginationModule,
    FileUploadModule
  ]
})
export class SharedModule { }

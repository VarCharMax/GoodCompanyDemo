import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from 'src/app/header/header.component';
import { InventoryComponent } from 'src/app/inventory/inventory.component';
import { InventoryListComponent } from 'src/app/inventory/inventorylist/inventorylist.component';
import { InventoryDetailComponent } from 'src/app/inventory/inventorydetail/inventorydetail.component';
import { ManageComponent } from 'src/app/inventory/manage/manage.component';
import { AppComponent } from './app.component';
import { BaseFormComponent } from 'src/app/inventory/manage/base.form.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    BaseFormComponent,
    HeaderComponent,
    InventoryComponent,
    InventoryListComponent,
    InventoryDetailComponent,
    ManageComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: InventoryComponent, pathMatch: 'full' },
      { path: 'manage', component: ManageComponent, pathMatch: 'full' },
    ]),
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

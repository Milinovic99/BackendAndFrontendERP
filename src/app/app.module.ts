import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon'
import {MatToolbarModule} from '@angular/material/toolbar'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {MatInputModule} from  '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTabsModule} from '@angular/material/tabs';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatTableModule} from '@angular/material/table';
import { BeerComponent } from './pages/beer/beer/beer.component';
import { WaterComponent } from './pages/water/water/water.component';
import { CarbonatedJuicesComponent } from './pages/carbonated_juices/carbonated-juices/carbonated-juices.component';
import { ContactComponent } from './pages/contact/contact/contact.component';
import { HomeComponent } from './pages/home/home/home.component';
import { ActionsComponent } from './pages/actions/actions/actions.component';
import { LoginComponent } from './pages/login/login/login.component';
import { RegistrationComponent } from './pages/registration/registration/registration.component';
import { DeliveryComponent } from './pages/delivery/delivery/delivery.component';
import { UserProfilesComponent } from './pages/user-profiles/user-profiles/user-profiles.component';
import {MatListModule} from '@angular/material/list';
import { HttpClientModule } from '@angular/common/http';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatMenuModule} from '@angular/material/menu';
import { DeliveryDataComponent } from './pages/delivery-data/delivery-data.component';
import {MatPaginatorModule} from '@angular/material/paginator';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { CoffeComponent } from './pages/coffe/coffe.component';
import { WineAndChampaignComponent } from './pages/wine-and-champaign/wine-and-champaign.component';
import { HotChocolateComponent } from './pages/hot-chocolate/hot-chocolate.component';
import { TeaComponent } from './pages/tea/tea.component';
import { EnergeticDrinksComponent } from './pages/energetic-drinks/energetic-drinks.component';
import { CartComponent } from './pages/cart/cart.component';
import { NgxPaginationModule } from 'ngx-pagination';
import {MatDialogModule} from '@angular/material/dialog';
import { BeerDialogComponent } from './dialogs/beer-dialog/beer-dialog.component';
import { TeaDialogComponent } from './dialogs/tea-dialog/tea-dialog.component';
import { CoffeeDialogComponent } from './dialogs/coffee-dialog/coffee-dialog.component';
import { JuiceDialogComponent } from './dialogs/juice-dialog/juice-dialog.component';
import { WineAndChampaignDialogComponent } from './dialogs/wine-and-champaign-dialog/wine-and-champaign-dialog.component';
import { ProductsComponent } from './pages/products/products.component';
import {MatSelectModule} from  '@angular/material/select';
import { WaterDialogComponent } from './dialogs/water-dialog/water-dialog.component';
import { EnergeticDrinkDialogComponent } from './dialogs/energetic-drink-dialog/energetic-drink-dialog.component';
import { ActionDialogComponent } from './dialogs/action-dialog/action-dialog.component';
import { AllProductsDialogComponent } from './dialogs/all-products-dialog/all-products-dialog.component';
import {MatBadgeModule} from '@angular/material/badge';
import { NotificationsComponent } from './pages/notifications/notifications.component';
import { RatingDialogComponent } from './dialogs/rating-dialog/rating-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    BeerComponent,
    WaterComponent,
    CarbonatedJuicesComponent,
    ContactComponent,
    HomeComponent,
    ActionsComponent,
    LoginComponent,
    RegistrationComponent,
    DeliveryComponent,
    UserProfilesComponent,
    DeliveryDataComponent,
    CoffeComponent,
    WineAndChampaignComponent,
    HotChocolateComponent,
    TeaComponent,
    EnergeticDrinksComponent,
    CartComponent,
    BeerDialogComponent,
    TeaDialogComponent,
    CoffeeDialogComponent,
    JuiceDialogComponent,
    WineAndChampaignDialogComponent,
    ProductsComponent,
    WaterDialogComponent,
    EnergeticDrinkDialogComponent,
    ActionDialogComponent,
    AllProductsDialogComponent,
    NotificationsComponent,
    RatingDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatIconModule,
    MatToolbarModule,
    MatInputModule,
    MatTabsModule,
    MatSidenavModule,
    MatTableModule,
    MatListModule,
    HttpClientModule,
    MatSnackBarModule,
    MatMenuModule,
    MatPaginatorModule,
    Ng2SearchPipeModule,
    NgxPaginationModule,
    MatDialogModule,
    MatSelectModule,
    MatBadgeModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]

})
export class AppModule { }

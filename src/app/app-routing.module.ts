import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActionsComponent } from './pages/actions/actions/actions.component';
import { BeerComponent } from './pages/beer/beer/beer.component';
import { CarbonatedJuicesComponent } from './pages/carbonated_juices/carbonated-juices/carbonated-juices.component';
import { ContactComponent } from './pages/contact/contact/contact.component';
import { HomeComponent } from './pages/home/home/home.component';
import { WaterComponent } from './pages/water/water/water.component';
import {LoginComponent} from './pages/login/login/login.component';
import { RegistrationComponent } from './pages/registration/registration/registration.component';
import { DeliveryComponent } from './pages/delivery/delivery/delivery.component';
import { UserProfilesComponent } from './pages/user-profiles/user-profiles/user-profiles.component';
import { DeliveryDataComponent } from './pages/delivery-data/delivery-data.component';
import { EnergeticDrinksComponent } from './pages/energetic-drinks/energetic-drinks.component';
import { TeaComponent } from './pages/tea/tea.component';
import { CoffeComponent } from './pages/coffe/coffe.component';
import { HotChocolateComponent } from './pages/hot-chocolate/hot-chocolate.component';
import { WineAndChampaignComponent } from './pages/wine-and-champaign/wine-and-champaign.component';
import { CartComponent } from './pages/cart/cart.component';
import { ProductsComponent } from './pages/products/products.component';
import { NotificationsComponent } from './pages/notifications/notifications.component';

const routes: Routes = [
    {path: 'beer', component: BeerComponent},
    {path: 'carbonated_juices', component: CarbonatedJuicesComponent},
    {path: 'contact', component: ContactComponent},
    {path: 'home', component: HomeComponent},
    {path: 'water', component: WaterComponent},
    {path: 'actions', component: ActionsComponent},
    {path: 'login' ,component:LoginComponent},
    {path: 'registration',component:RegistrationComponent},
    {path: 'delivery',component:DeliveryComponent},
    {path:'user-profile',component:UserProfilesComponent},
    {path:'delivery-data',component:DeliveryDataComponent},
    {path:'energetic-drinks',component:EnergeticDrinksComponent},
    {path:'tea',component:TeaComponent},
    {path:'coffee',component:CoffeComponent},
    {path:'hot-chocolate',component:HotChocolateComponent},
    {path:'wine-and-champaign',component:WineAndChampaignComponent},
    {path:'cart',component:CartComponent},
    {path:'products',component:ProductsComponent},
    {path:'notifications',component:NotificationsComponent},
    {path: '', redirectTo: '/home', pathMatch: 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

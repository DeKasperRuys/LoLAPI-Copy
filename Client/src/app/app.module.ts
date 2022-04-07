import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { JwPaginationComponent } from 'jw-angular-pagination';
import { NgxPaginationModule } from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import {RouterModule} from '@angular/router';
import { InternetAPIComponent } from './internet-api/internet-api.component';
import { TheclassComponent } from './internet-api/Class/theclass/theclass.component';
import { TheraceComponent } from './internet-api/Race/therace/therace.component';
import { ThespellsComponent } from './internet-api/Spells/thespells/thespells.component';

import { SocialLoginModule, SocialAuthServiceConfig } from 'angularx-social-login';
import { GoogleLoginProvider,FacebookLoginProvider } from 'angularx-social-login';

// import {ToastaModule} from 'ngx-toasta'
import { FormsModule, ReactiveFormsModule, Validator, FormControl, FormGroup, FormBuilder} from '@angular/forms';
import { AuthComponent } from './auth/auth.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    InternetAPIComponent,
    TheclassComponent,
    TheraceComponent,
    ThespellsComponent,
    AuthComponent
  ],
  imports: [

    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    SocialLoginModule,
    NgxPaginationModule,
    RouterModule.forRoot([
      { path: "API", component: InternetAPIComponent},
      { path: "LoLAPI", component: HomeComponent},
    ])
  ],
  providers: 
  [
    {
    provide: 'SocialAuthServiceConfig',
    useValue: {
      autoLogin: false,
      providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
             '960860835486-66osebfn8jjagkmf06qg1f77o5gajnsb.apps.googleusercontent.com'
            )
          },
          {
            id: FacebookLoginProvider.PROVIDER_ID,
            provider: new FacebookLoginProvider('clientId')
          }
        ]
      } as SocialAuthServiceConfig,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule, routes } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'


import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button'


import { MenuBarComponent } from './_shared/menu/menu-bar/menu-bar.component';
import { MenuButtonComponent } from './_shared/menu/menu-button/menu-button.component';
import { MenuIconComponent } from './_shared/menu/menu-icon/menu-icon.component';
import { MenuItemComponent } from './_shared/menu/menu-item/menu-item.component';
import { LoginComponent } from './_components/login/login.component';
import { PrincipalPageComponent } from './_components/principal-page/principal-page.component';
import { RouterModule } from '@angular/router';
import { authGuardGuard } from './_shared/guards/auth-guard.guard';
import { ArticleCardComponent } from './_components/article-card/article-card.component';
import { CarrouselImagesComponent } from './_components/carrousel-images/carrousel-images.component';
import { ArticleViewerComponent } from './_components/article-viewer/article-viewer.component';
import { ButtonComponent } from './_shared/button/button.component';


@NgModule({
  declarations: [
    AppComponent,
    MenuBarComponent,
    MenuButtonComponent,
    MenuIconComponent,
    MenuItemComponent,
    LoginComponent,
    PrincipalPageComponent,
    ArticleCardComponent,
    CarrouselImagesComponent,
    ArticleViewerComponent,
    ButtonComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatSlideToggleModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

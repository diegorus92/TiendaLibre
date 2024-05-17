import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './_components/login/login.component';
import { PrincipalPageComponent } from './_components/principal-page/principal-page.component';
import { MenuBarComponent } from './_shared/menu/menu-bar/menu-bar.component';
import { authGuardGuard } from './_shared/guards/auth-guard.guard';
import { ArticleViewerComponent } from './_components/article-viewer/article-viewer.component';

export const routes: Routes = [
  {path:'principal-page', component:PrincipalPageComponent},
  {path:"login", component:LoginComponent},

  {path:'menu-bar', component:MenuBarComponent, children:[
    { path:'principal-page', component:PrincipalPageComponent },
    { path: 'login', component:LoginComponent, canActivate:[authGuardGuard]},
    { path: 'article-viewer', component:ArticleViewerComponent }
  ]},

  {path:'', redirectTo:"menu-bar/principal-page", pathMatch:"full"},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers:[MenuBarComponent]
})
export class AppRoutingModule { }

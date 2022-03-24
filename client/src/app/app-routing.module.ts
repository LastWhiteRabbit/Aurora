import {NgModule} from "@angular/core";
import {Routes, RouterModule} from "@angular/router";
import {HomeComponent} from "./home/home.component";
import {MessagesComponent} from "./messages/messages.component";
import {TrackListComponent} from "./tracks/track-list/track-list.component";
import {TrackDetailComponent} from "./tracks/track-detail/track-detail.component";
import {ArtistsComponent} from "./artists/artists.component";
import {GenresComponent} from "./genres/genres.component";
import {AlbumsComponent} from "./albums/albums.component";
import {PlaylistsComponent} from "./playlists/playlists.component";
import {AuthGuard} from "./_guards/auth.guard";

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path:'',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children:[
      {path: 'tracks', component: TrackListComponent, canActivate: [AuthGuard]},
      {path: 'tracks/:id', component: TrackDetailComponent},
      {path: 'artists', component: ArtistsComponent},
      {path: 'genres', component: GenresComponent},
      {path: 'albums', component: AlbumsComponent},
      {path: 'playlists', component: PlaylistsComponent},
      {path: 'messages', component: MessagesComponent},
    ]
  },
  {path: '**', component: HomeComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule{ }

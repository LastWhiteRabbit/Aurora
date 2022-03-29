import {Cover} from "./cover";

export interface Album {
    id: number;
    albumName: string;
    albumLength: number;
    created: Date;
    cover: Cover;
}

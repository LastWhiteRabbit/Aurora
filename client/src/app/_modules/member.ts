import {Photo} from "./photo";

export interface Member {
  id: number
  username: string
  photoUrl: string
  created: Date
  lastActive: Date
  location: string
  about: string
  photos: Photo[]
}


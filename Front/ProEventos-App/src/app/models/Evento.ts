import { Lote } from "./Lote";
import { Palestrante } from "./Palestrante";
import { RedeSocial } from "./RedeSocial";

export interface Evento {
  local: string
  id: number
  dataEvento?: Date
  tema: string
  qtdPessoas: number
  imageURL: string
  telefone: string
  email: string
  lotes: Lote[];
  redesSociais: RedeSocial[];
  palestrantesEventos: Palestrante[];
}

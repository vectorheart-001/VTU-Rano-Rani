// See https://kit.svelte.dev/docs/types#app
// for information about these interfaces


type User = {
	id: number
	email: string
	major: string
	name:string
	phone:string
	personalId:string
	request_status:string
	
}
type Major ={
	id: string,
	name:string,
	placesLeft:number
}

declare global {
	namespace App {
		// interface Error {}
		interface Locals {
			user: User | null
			
		}
		// interface PageData {}
		// interface PageState {}
		// interface Platform {}
	}
	
}

export {};

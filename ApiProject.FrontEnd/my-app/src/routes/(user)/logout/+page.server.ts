import { redirect } from '@sveltejs/kit'

export const load = async () => {
	throw redirect(302, '/')
}

export  const actions = {
	default:async({ cookies }) => {
		
		const response = await fetch(`http://localhost:7162/User/logout`,
        { 
            method: "DELETE",
            headers: { 
				'Content-Type': 'application/json',
				'Authorization': `Bearer ${cookies.get('token')}`
			 },

			 
        },
		
		)

		
		cookies.set('token', '', {
			path: '/',
			expires: new Date(0),
		})
		cookies.set('refreshToken', '', {
			path: '/',
			expires: new Date(0),
		})

		
		
		throw redirect(302, '/')
	},
}
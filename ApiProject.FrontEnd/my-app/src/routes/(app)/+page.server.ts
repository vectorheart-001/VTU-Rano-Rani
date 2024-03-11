import type { PageServerLoad } from './$types';
export const load = async ({locals}) => {
    
    const fetchMajors = async () => {
        const res = await fetch(`http://localhost:7162/Major/get-all`)
        const data = await res.json()
        const user = locals.user
        
        let majorData = data
        
        return majorData 
    }

    return {
        major: await fetchMajors(),
    }
}

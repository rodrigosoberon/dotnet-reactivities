import { Link } from 'react-router-dom'
import { Header, Segment, Icon, Button } from 'semantic-ui-react'

export default function NotFound() {
	return (
		<Segment placeholder>
			<Header icon>
				<Icon name='search' />
				We couldn't find what you were looking for, pa!
			</Header>
			<Segment.Inline>
				<Button as={Link} to='/activities'>
					Go to Activities page
				</Button>
			</Segment.Inline>
		</Segment>
	)
}
